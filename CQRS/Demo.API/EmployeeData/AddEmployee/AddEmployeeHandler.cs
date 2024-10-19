

namespace Demo.API.EmployeeData.AddEmployee
{

    public record AddEmployeeCommand(string FirstName,string LastName,
        string Gender,string Department,decimal Salary):ICommand<AddEmployeeResult>;
    public record AddEmployeeResult(Guid id);
    public class AddEmployeeCommandHandler : ICommandHandler<AddEmployeeCommand, AddEmployeeResult>
    {
        public async Task<AddEmployeeResult> Handle(AddEmployeeCommand command, CancellationToken cancellationToken)
        {
            //implement Businss Logic

            //1. Cretae employee Object from command Parameter
            var employee = new Employee
            {
                Id = new Guid(),
                FirstName = command.FirstName,
                LastName = command.LastName,
                Department = command.Department,
                Gender = (Gender)Enum.Parse(typeof(Gender), command.Gender),
                Salary = 50000
            };
            //2. Save To Database

            //3. Return Result
            return  new AddEmployeeResult(employee.Id);

           
        }
    }
}
