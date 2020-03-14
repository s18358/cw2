namespace cw2
{
    public class Student
    {
        private string Line;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Studies { get; set; }
        public string StudType { get; set; }
        public string Index { get; set; }
        public string BirthDate { get; set; }
        public string Email { get; set; }
        public string Mother { get; set; }
        public string Father { get; set; }

        public Student(string line)
        {
            this.Line = line;
            var stud = line.Split(",");
            this.FirstName = stud[0];
            this.LastName = stud[1];
            this.Studies = stud[2];
            this.StudType = stud[3];
            this.Index = stud[4];
            this.BirthDate = stud[5];
            this.Email = stud[6];
            this.Mother = stud[7];
            this.Father = stud[8];
        }

        public override string ToString()
        {
            return Line;
        }
    }
}