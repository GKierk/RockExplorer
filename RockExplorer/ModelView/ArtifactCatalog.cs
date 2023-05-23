/*
 *Authors: Mohamad Kassem
 *Date: 09-05-2023
 * Edited by: Gabriel H. Kierkegaard, Date: 10-09-2023
 * Edited by: Gabriel H. Kierkegaard, Date: 15-09-2023
 * Edited by: Gabriel H. Kierkegaard, Date: 16-09-2023
 * Edited by: Gabriel H. Kierkegaard, Date: 17-09-2023
 * Edited by: Gabriel H. Kierkegaard, Date: 20-09-2023
 */



using RockExplorer.Model;
using RockExplorer.Helpers;

namespace RockExplorer.ModelView
{
    public class ArtifactCatalog : ICRUD<Artifact>
    {
        private static ArtifactCatalog instance = null;
        private string JsonFileName = @"Data\JsonArtifacts.json";

        public ArtifactCatalog()
        {
            Artifacts = ReadAll();
        }

        //private int dictionarySize;

        // Her har vi lavet en Dictionary, som beskriver vores Artifacts-Mk
        //public ArtifactCatalog()
        //{
        //    Artifacts = new Dictionary<int, Artifact>();

        //    Artifacts.Add(1, new Artifact { Name = "the black guitar", Description = "First black electric guitar ever made", PathToAudioFile = "XXX", PathToImage = "guitar.jfif", YearOfCreation = 1875, Artist = "Momo" });
        //    Artifacts.Add(2, new Artifact { Name = "XXX", Description = "XXX", PathToAudioFile = "XXX", PathToImage = "XXX", YearOfCreation = 123, Artist = "XXX" });
        //    Artifacts.Add(3, new Artifact { Name = "XXX", Description = "XXX", PathToAudioFile = "XXX", PathToImage = "XXX", YearOfCreation = 123, Artist = "XXX" });
        //    dictionarySize = Artifacts.Count;
        //}

        public Dictionary<int, Artifact> Artifacts { get; private set; }
        public int key { get; set; }

        public static ArtifactCatalog Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ArtifactCatalog();
                }

                return instance;
            }
        }


        // hvis en person forsøger at tilføje et nyt objekt til samlingen og det objekts ID allerede findes, så bliver objektet ikke tilføjet til samlingen. - Mk
        // Ellers bliver det nye objekt tilføjet til samlingen.-Mk
        public void Create(Artifact entity)
        {
            //ArtifactCatalog cat = instance;
            //dictionarySize++;
            //cat.Artifacts.Add(dictionarySize, entity);

            ArtifactCatalog cat = ArtifactCatalog.Instance;
            int dictionarySize = ReadAll().Count();
            dictionarySize++;

            cat.Artifacts.Add(dictionarySize, entity);
            JsonFileHandler.WriteToJson(JsonFileName);
        }


        //Hvis du kender ID'en for en artifact, kan du bruge denne metode til at hente artifacten fra en samling af Artifacts og få adgang til dens beskrivelser.-Mk
        public Artifact Read(int id)

        {
            return Artifacts[id];

        }

        // Metoden her giver dig en liste over alle artifacts, som er gemt i en database. - Mk
        // Hver artifact har et nummer, som kan bruges til at finde yderligere information om genstanden i databasen.-Mk
        public Dictionary<int, Artifact> ReadAll()
        {
            return JsonFileHandler.ReadJson(JsonFileName);
        }

        //hvis du har en liste med artifacter og du ønsker at opdatere en af dem, kan du bruge denne metode til at erstatte den gamle artifact med den nye.-Mk
        public void Update(int key, Artifact entity)
        {
            ArtifactCatalog cat = instance;

            if (entity != null && cat.Artifacts.ContainsKey(key))
            {
                cat.Artifacts[key].Name = entity.Name;
                cat.Artifacts[key].Description = entity.Description;
                cat.Artifacts[key].PathToAudioFile = entity.PathToAudioFile;
                cat.Artifacts[key].PathToImage = entity.PathToImage;
                cat.Artifacts[key].YearOfCreation = entity.YearOfCreation;
                cat.Artifacts[key].Artist = entity.Artist;
            }

            JsonFileHandler.WriteToJson(JsonFileName);
        }
        //Metoden sletter en genstand fra listen ved at bruge det angivne ID.-Mk
        public void Delete(int key)
        {
            ArtifactCatalog cat = Instance;
            Dictionary<int, Artifact> tempDictionary = new Dictionary<int, Artifact>();
            int counter = 1;
            int decrementer;

            // Slet artifact med tilsvarende key
            cat.Artifacts.Remove(key);

            // Kopier artifact liste til midlertidig liste, hvor der dekrementeres.
            foreach (var kvp in cat.Artifacts)
            {

                if (counter <= cat.Artifacts.Count + 1)
                {
                    if (cat.Artifacts.ContainsKey(counter))
                    {
                        tempDictionary.Add(counter, cat.Artifacts[kvp.Key]);
                    }
                    else if(!cat.Artifacts.ContainsKey(counter))
                    {

                        decrementer = counter;
                        tempDictionary.Add(--decrementer, cat.Artifacts[kvp.Key]);

                    }

                    

                }
                counter++;
            }
            cat.Artifacts.Clear();
            cat.Artifacts = tempDictionary;
            JsonFileHandler.WriteToJson(JsonFileName);
        }


        // FilterArtifact !! Denne metode hjælper en person med at finde en bestemt artefakt baseret på en del af navnet,- Mk
        // og returnerer en liste over artefakter, der passer til dette kriterium.-Mk

        public Dictionary<int, Artifact> FilterArtifact(string criteria)
        {
            Dictionary<int, Artifact> myArtifacts = new Dictionary<int, Artifact>();

            if (criteria != null)
            {
                foreach (KeyValuePair<int, Artifact> kvp in Artifacts)
                {
                    bool filter = kvp.Value.YearOfCreation != null;
                    if (kvp.Value.Name != null && kvp.Value.Name.ToLower().StartsWith(criteria.ToLower()))
                    {
                        myArtifacts.Add(kvp.Key, kvp.Value);
                    }
                    else if (kvp.Value.Description != null && kvp.Value.Description.ToLower().StartsWith(criteria.ToLower()))
                    {
                        myArtifacts.Add(kvp.Key, kvp.Value);
                    }
                    else if (kvp.Value.Artist != null && kvp.Value.Artist.ToLower().StartsWith(criteria.ToLower()))
                    {
                        myArtifacts.Add(kvp.Key, kvp.Value);
                    }
                    else if (filter && kvp.Value.YearOfCreation.ToString().StartsWith(criteria.ToLower()))
                    {
                        myArtifacts.Add(kvp.Key, kvp.Value);
                    }
                }
            }

            return myArtifacts;
        }

    }
}
