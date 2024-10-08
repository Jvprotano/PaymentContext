using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Queries;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.Queries;
[TestClass]
public class StudentQueriesTest
{
    private IList<Student> _students;

    public StudentQueriesTest()
    {
        _students = new List<Student>();

        for (var i = 0; i <= 10; i++)
        {
            _students.Add(new Student(
                new Name("Aluno", i.ToString()),
                new Document("1111111111" + i.ToString(), EDocumentType.CPF),
                new Email(i.ToString())));
        }
    }
    [TestMethod]
    public void ShouldReturnNullWhenDocumentNotExists()
    {
        var exp = StudentQueries.GetStudentInfo("1234567891011");
        var student = _students.AsQueryable().Where(exp).FirstOrDefault();

        Assert.AreEqual(null, student);
    }
    [TestMethod]
    public void ShouldReturnStudentWhenDocumentExists()
    {
        var exp = StudentQueries.GetStudentInfo("11111111111");
        var student = _students.AsQueryable().Where(exp).FirstOrDefault();

        Assert.AreNotEqual(null, student);
    }
}