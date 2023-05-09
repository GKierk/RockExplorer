/*
 * Author: Gabriel H. Kierkegaard
 * Date: 2023-05-09
 * moimo was here 
 */

namespace RockExplorer.Model
{
    public class Person
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public int MobileNumber { get; set; }
        public string? Email { get; set; }
        public bool IsEmployee { get; set; }
    }
}
