using Bogus.DataSets;
using GraphQLDemo.API.Schema;

namespace GraphQLDemo.API.Mutation
{
    public class Mutation
    {
        private readonly List<CourseResult> _course;

        public Mutation()
        {
            _course = new List<CourseResult>();
        }
        public CourseResult CreateCourse(CourseInput courseInput)
        {
            CourseResult courseType = new CourseResult()
            {
                Id = Guid.NewGuid(),
                Name = courseInput.Name,
                Subject = courseInput.Subject,
                InstructorId = courseInput.InstructorId

            };
            _course.Add(courseType);
            return courseType;
        }

        public CourseResult UpdateCourse(Guid id, CourseInput courseInput)
        {
            CourseResult course=_course.FirstOrDefault(c => c.Id == id);
            if(course==null)
            {
                throw new Exception("no course not found");
            }
            course.Name = courseInput.Name;
            course.Subject = courseInput.Subject;
            course.InstructorId = courseInput.InstructorId;
            return course;
        }

        public bool DeleteCourse(Guid id)
        {
            return _course.RemoveAll(c => c.Id == id) >=1;
        }
    }
}
