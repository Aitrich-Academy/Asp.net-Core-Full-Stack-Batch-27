namespace Activity.Data
{
    public class Entry
    {
        public float Amount {  get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Entry() { }
        public Entry(float amount,string name,string description) 
        {
            Amount = amount;
            Name = name;
            Description = description;
        }

    }
}
