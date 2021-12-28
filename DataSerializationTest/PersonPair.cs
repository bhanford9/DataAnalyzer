namespace DataSerializationTest
{
  public class PersonPair
  {
    public PersonPair() { }

    public PersonPair(Person person1, Person person2)
    {
      this.Person1 = person1;
      this.Person2 = person2;
    }

    public Person Person1 { get; set; } = new Person();

    public Person Person2 { get; set; } = new Person();
  }
}
