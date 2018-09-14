using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace FireAndIceApp
{
	class Program
	{
		static void Main(string[] args)
		{
			// Get it working
			// Refactor
			//  - Must do: remove duplication
			//  - If there is time, make it fancy (maintainable)

			string top = @"
				<!DOCTYPE html>
				<html>
				<head>
					<link href='https://fonts.googleapis.com/css?family=Lato' rel='stylesheet'>
					<link href='https://fonts.googleapis.com/css?family=Merienda' rel='stylesheet'>
					<link href='style.css' rel='stylesheet'>	
				</head>	
				  <body>
					<div class='header-section shadow'><h1>Point of View Characters in Game of Thrones</h1></div>


			";

			string bottom = @"
				  </body>
				</html>
			";

			

			var url = "https://anapioficeandfire.com/api/books/1";

			var client = new RestClient(url);

			var response = client.Execute<Book>(new RestRequest());
			var bookName = response.Data.Name;
			var charUrls = response.Data.PovCharacters;

			var charactersQuery = charUrls.Select(charUrl =>
			{
				var charClient = new RestClient(charUrl);
				var res = charClient.Execute<Character>(new RestRequest());
				return res.Data;
			});

			var characters = charactersQuery.ToList();

			var bookNameAsHtml = $"<h2 class='book-title shadow'>{bookName}</h2>";

			// Aggrigate - go over a list and end up with one item
			// Select - go over a list, and map each item to a new item - end up with a list of the same size

			var charactersAsHtml = "<div class='characters'>";
			foreach (Character character in characters)
			{
				var charAsHtml = $"<div class='character shadow {(character.Died == "" ? "" : "dead")}'>" +
									$"<div>{ character.Name }</div>" +
									$"<div>{ character.Alive }</div>" +
									$"<div>{ character.Culture }</div>" +
								  "</div>";
				charactersAsHtml += charAsHtml;
			}

			var middle = bookNameAsHtml + charactersAsHtml + "</div>";



			File.WriteAllText("./index.html", top + middle + bottom);

//			Console.ReadKey();

		}
	}

	public class Book
	{
		public string Name { get; set; }
		public List<string> PovCharacters { get; set; }
	}

	public class Character
	{
		public string Name { get; set; }
		public string Culture { get; set; }
		public string Died { get; set; }

		public string Alive => Died == "" ? "Alive" : "Dead"; // ? true : false);

		public override string ToString()
		{
			return $"{Name} {Culture} { Alive }";
		}
	}
}
