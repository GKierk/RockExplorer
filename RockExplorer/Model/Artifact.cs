/*
 *Authors: Gülsüm og Nuriye Erdogan
 *Date: 09-05-2023
 */

//Koden definerer en simpel klasse ved navn "Artifact", der repræsenterer et kunstværk eller genstand og 
//har forskellige attributter som navn, beskrivelse, filstier, år for oprettelse, kunstner og en unik identifikations-ID.-MK
namespace RockExplorer.Model
{
    public class Artifact
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? PathToAudioFile { get; set; }
        public string? PathToImage { get; set; }
        public int YearOfCreation { get; set; }
        public string? Artist { get; set; }
    }


}