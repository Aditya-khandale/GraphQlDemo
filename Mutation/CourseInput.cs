using GraphQLDemo.API.Models;
using GraphQLDemo.API.Schema;

namespace GraphQLDemo.API.Mutation
{
    public class CourseInput
    {
        public string Name { get; set; }
        public Subject Subject { get; set; }
        public Guid InstructorId { get; set; }
    }
}
