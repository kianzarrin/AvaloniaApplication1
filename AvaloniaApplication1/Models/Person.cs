namespace AvaloniaApplication1.Models {
    public class PersonBase {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class Person: PersonBase {
        public int DepartmentNumber { get; set; }
        public string DeskLocation { get; set; }
        public int EmployeeNumber { get; set; }

    }
}
