﻿using Bogus;
using GraphQLDemo.API.Models;

namespace GraphQLDemo.API.Schema
{
    public class Query
    {
        private readonly Faker<InstructorType> _instructorFaker;
        private readonly Faker<StudentType> _studentFaker;
        private readonly Faker<CourseType> _courseFaker;
        public Query()
        {
            _instructorFaker = new Faker<InstructorType>()
                .RuleFor(c => c.Id, f => Guid.NewGuid())
                .RuleFor(c => c.FirstName, f => f.Name.FirstName())
                .RuleFor(c => c.LastName, f => f.Name.LastName())
                .RuleFor(c => c.Salary, f => f.Random.Double(0, 100000));

            _studentFaker = new Faker<StudentType>()
                 .RuleFor(c => c.Id, f => Guid.NewGuid())
                .RuleFor(c => c.FirstName, f => f.Name.FirstName())
                .RuleFor(c => c.LastName, f => f.Name.LastName())
                .RuleFor(c => c.GPA, f => f.Random.Double(1, 4));

            _courseFaker = new Faker<CourseType>()
                .RuleFor(c => c.Id, f => Guid.NewGuid())
                .RuleFor(c => c.Name, f => f.Name.JobTitle())
                .RuleFor(c => c.Subject, f => f.PickRandom<Subject>())
                .RuleFor(c => c.Instructor, f => _instructorFaker.Generate())
                .RuleFor(c => c.Students, f => _studentFaker.Generate(3));
        }
        public IEnumerable<CourseType> GetCourses()
        {
            return _courseFaker.Generate(5);
        }
           
        public async Task<CourseType> GetCourseByIdAsync(Guid id)
        {
            await Task.Delay(1000);
            CourseType Course = _courseFaker.Generate();
            Course.Id = id;
            return Course;
        }
            //return new List<CourseType>()
            //{
            //     new CourseType()
            //     {
            //         Id=Guid.NewGuid(),
            //         Name="Geometry",
            //         Subject=Subject.Mathematics,
            //         Instructor=new InstructorType()
            //         {
            //             Id = Guid.NewGuid(),
            //         }
            //     }
            //}
        
        //[GraphQLDeprecated("This query is depricated:")]
        //public string Instructions => "My name is aditya khandale";
    }
}
