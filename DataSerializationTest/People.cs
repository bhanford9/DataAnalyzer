using System.Collections.Generic;

namespace DataSerializationTest
{
  public class People
  {
    public ICollection<Person> Persons { get; set; } = new List<Person>();
  }
}
