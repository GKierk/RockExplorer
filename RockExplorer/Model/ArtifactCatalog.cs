/*
 *Authors: Mohamad Kassem
 *Date: 09-05-2023
 * Edited by: Gabriel H. Kierkegaard, Date: 10-09-2023
 * Edited by: Gabriel H. Kierkegaard, Date: 15-09-2023
 * Edited by: Gabriel H. Kierkegaard, Date: 16-09-2023
 */


using RockExplorer.Interfaces;

namespace RockExplorer.Model
{
    public class ArtifactCatalog: ICRUD<Artifact>
    {
        private static ArtifactCatalog instance = null;
        private ArtifactCatalog catalog;
        private Dictionary<int, Artifact> Artifacts { get; }
        private int dictionarySize;
        // Her har vi lavet en Dictionary, som beskriver vores Artifacts
        public ArtifactCatalog() 
        {
            Artifacts = new Dictionary<int,Artifact>();
            Artifacts.Add(1, new Artifact { Name = "the black guitar", Description = "First black electric guitar ever made", PathToAudioFile = "XXX", PathToImage = "guitar.jfif", YearOfCreation = 1875, Artist = "Momo" });
            Artifacts.Add(2, new Artifact { Name = "XXX", Description = "XXX", PathToAudioFile = "XXX", PathToImage = "XXX", YearOfCreation = 123, Artist = "XXX" });
            Artifacts.Add(3, new Artifact { Name = "XXX", Description = "XXX", PathToAudioFile = "XXX", PathToImage = "XXX", YearOfCreation = 123, Artist = "XXX" });
            dictionarySize = Artifacts.Count;
        }

        public static ArtifactCatalog Instace
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


        // hvis en person forsøger at tilføje et nyt objekt til samlingen og det objekts ID allerede findes, så bliver objektet ikke tilføjet til samlingen. 
        // Ellers bliver det nye objekt tilføjet til samlingen.
        public void Create(Artifact entity) 
        {
            ArtifactCatalog cat = ArtifactCatalog.instance;
            dictionarySize++;
            cat.Artifacts.Add(dictionarySize, entity);
        }


        //Hvis du kender ID'en for en artifact, kan du bruge denne metode til at hente artifacten fra en samling af Artifacts og få adgang til dens beskrivelser.
        public Artifact Read(int id)
        
        {
            return Artifacts[id];

        }

        // Metoden her giver dig en liste over alle artifacts, som er gemt i en database. 
        // Hver artifact har et nummer, som kan bruges til at finde yderligere information om genstanden i databasen.
        public Dictionary<int, Artifact> ReadAll()
        {
            return Artifacts;
        }

        //hvis du har en liste med artifacter og du ønsker at opdatere en af dem, kan du bruge denne metode til at erstatte den gamle artifact med den nye.
        public void Update(Artifact entity)
        {
            ArtifactCatalog cat = ArtifactCatalog.instance;

            if (entity != null)
            {
                foreach (var kvp in cat.Artifacts)
                {
                    if (cat.Artifacts.Keys.Equals(kvp.Key))
                    {
                        kvp.Value.Name = entity.Name;
                        kvp.Value.Description = entity.Description;
                        kvp.Value.PathToAudioFile = entity.PathToAudioFile;
                        kvp.Value.PathToImage = entity.PathToImage;
                        kvp.Value.YearOfCreation = entity.YearOfCreation;
                        kvp.Value.Artist = entity.Artist;
                    }
                }
            }
        }
        //Metoden sletter en genstand fra listen ved at bruge det angivne ID.
        public void Delete(int id)
        {
            ArtifactCatalog cat = ArtifactCatalog.Instace;
            cat.Artifacts.Remove(id);
        }

       
        // FilterArtifact !! Denne metode hjælper en person med at finde en bestemt artefakt baseret på en del af navnet,
        // og returnerer en liste over artefakter, der passer til dette kriterium.

        public Dictionary<int, Artifact> FilterArtifact (string criteria)
        {
            Dictionary<int, Artifact> myArtifacts = new Dictionary<int, Artifact> ();
            if (criteria != null)
            {
                foreach (Artifact A in Artifacts.Values)
                {
                    if (A.Name != null)
                    {
                        if (A.Name.ToLower().StartsWith(criteria.ToLower()))
                        {
                            //myArtifacts.Add(A.ID, A);
                        }
                    }
                }
            }
            return myArtifacts;
        }
    }
}
