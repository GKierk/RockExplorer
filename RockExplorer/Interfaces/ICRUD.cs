using RockExplorer.Model;
// Denne metode beskriver et interface kaldet ICRUD, som definerer en række metoder til at udføre CRUD-operationer (Create, Read, Update og Delete) på en samling af "Artifact"-objekter.
namespace RockExplorer.Interfaces
{
    public interface ICRUD
    {
        Dictionary<int, Artifact> AllArtifacts();
        Dictionary<int, Artifact> FilterArtifact(string crtiteria);
        void Delete(int id);
        void AddArtifact(Artifact Artifact);
        void UpdateArtifact(Artifact Artifact);
        Artifact GetArtifact(int id);
    }
}
