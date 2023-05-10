/*
 *Authors: Gülsüm og Nuriye Erdogan
 *Date: 09-05-2023
 */
namespace RockExplorer.Model
{
    public class Artifact
    {

        public int ID { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? PathToAudioFile { get; set; }
        public string? PathToImage { get; set; }
        public int YearOfCreation { get; set; }
        public string? Artist { get; set; }

    }


}