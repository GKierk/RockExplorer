/*
 *Authors: Mohamad Kassem
 *Date: 09-05-2023
 * Edited by: Gabriel H. Kierkegaard, Date: 10-09-2023
 */


using RockExplorer.Interfaces;

namespace RockExplorer.Model
{
    public class ArtifactCatalog: ICRUD<Artifact>
    {
        private Dictionary<int, Artifact> Artifacts { get; }
        // Her har vi lavet en Dictionary, som beskriver vores Artifacts
        public ArtifactCatalog() 
        {
            Artifacts = new Dictionary<int,Artifact>();
            Artifacts.Add(1, new Artifact { ID = 1, Name = "the black guitar", Description = "First black electric guitar ever made", PathToAudioFile = "XXX", PathToImage = "guitar.jfif", YearOfCreation = 1875, Artist = "Momo" });
            Artifacts.Add(2, new Artifact { ID = 2, Name = "XXX", Description = "XXX", PathToAudioFile = "XXX", PathToImage = "XXX", YearOfCreation = 123, Artist = "XXX" });
            Artifacts.Add(3, new Artifact { ID = 3, Name = "XXX", Description = "XXX", PathToAudioFile = "XXX", PathToImage = "XXX", YearOfCreation = 123, Artist = "XXX" });
        }


        // hvis en person forsøger at tilføje et nyt objekt til samlingen og det objekts ID allerede findes, så bliver objektet ikke tilføjet til samlingen. 
        // Ellers bliver det nye objekt tilføjet til samlingen.
        public void Create(Artifact entity) 
        {
            if(!(Artifacts.Keys.Contains (entity.ID)))
                Artifacts.Add(entity.ID, entity);
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
            Artifacts[entity.ID] = entity;

        }
        //Metoden sletter en genstand fra listen ved at bruge det angivne ID.
        public void Delete(int id)
        {
            Artifacts.Remove(id);
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
                            myArtifacts.Add(A.ID, A);
                        }
                    }
                }
            }
            return myArtifacts;
        }
    }
}
