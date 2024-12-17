namespace Projecraft
{
    public class Category
    {
        public string categoryName {set; get;}
        public int hoursWorked {set; get;}
        public int minutesWorked {set; get;}
        public int secondsWorked {set; get;}

        public Category()
        {
            //Exists for JSON Deserialization
        }

        public Category(string cName)
        {
            categoryName = cName;
        }
    }
}