namespace Demo.API.EmployeeData.AddEmployee
{
    public record AddEmployeeRequest(string FirstName, string LastName, string Gender, string Department, decimal Salary);
    public record AddEmployeeRespon(Guid Id);
    public class AddEmployeeEndPoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/employee", async (AddEmployeeRequest request, ISender sender) =>
            {
                var command = request.Adapt<AddEmployeeCommand>();
                var result =await sender.Send(command);
                var response = result.Adapt<AddEmployeeRespon>();
                return Results.Created($"/employee/{response.Id}", response);
            })
            .WithName("Added New Employee")
            .Produces<AddEmployeeRespon>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status500InternalServerError)
            .WithSummary("Add Employee")
            .WithDescription("Add Employee");
        }
    }
}
