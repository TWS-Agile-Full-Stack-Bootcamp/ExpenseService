using System;
using Expense.Service;
using Expense.Service.Exceptions;
using Expense.Service.Expense;
using Expense.Service.Projects;
using Xunit;

namespace Expense.Service.Test
{
    public class ExpenseServiceTest
    {
        [Fact]
        public void Should_return_internal_expense_type_if_project_is_internal()
        {
            // given
            var internalProject = new Project(ProjectType.INTERNAL, string.Empty);
            // when
            var internalProjectExpense = ExpenseService.GetExpenseCodeByProjectTypeAndName(internalProject);
            // then
            Assert.Equal(ExpenseType.INTERNAL_PROJECT_EXPENSE, internalProjectExpense);
        }

        [Fact]
        public void Should_return_expense_type_A_if_project_is_external_and_name_is_project_A()
        {
            // given
            var projectAName = "Project A";
            var externalProject = new Project(ProjectType.EXTERNAL, projectAName);
            // when
            var expenseTypeA = ExpenseService.GetExpenseCodeByProjectTypeAndName(externalProject);
            // then
            Assert.Equal(ExpenseType.EXPENSE_TYPE_A, expenseTypeA);
        }

        [Fact]
        public void Should_return_expense_type_B_if_project_is_external_and_name_is_project_B()
        {
            // given
            var projectBName = "Project B";
            var externalProjectWitchNameIsProjectB = new Project(ProjectType.EXTERNAL, projectBName);
            // when
            var expenseTypeB = ExpenseService.GetExpenseCodeByProjectTypeAndName(externalProjectWitchNameIsProjectB);
            // then
            Assert.Equal(ExpenseType.EXPENSE_TYPE_B, expenseTypeB);
        }

        [Fact]
        public void Should_return_other_expense_type_if_project_is_external_and_has_other_name()
        {
            // given
            var otherName = "any";
            var externalProjectWithOtherName = new Project(ProjectType.EXTERNAL, otherName);
            // when
            var otherExpenseType = ExpenseService.GetExpenseCodeByProjectTypeAndName(externalProjectWithOtherName);
            // then
            Assert.Equal(ExpenseType.OTHER_EXPENSE, otherExpenseType);
        }

        [Fact]
        public void Should_throw_unexpected_project_exception_if_project_is_invalid()
        {
            // given
            var anyExpenseName = "any";
            var unexpectedProject = new Project(ProjectType.UNEXPECTED_PROJECT_TYPE, anyExpenseName);
            // when
            var unexpectedProjectTypeException = Assert.Throws<UnexpectedProjectTypeException>(() =>
            {
                ExpenseService.GetExpenseCodeByProjectTypeAndName(unexpectedProject);
            });
            // then
            Assert.Equal("You enter invalid project type", unexpectedProjectTypeException.Message);
        }
    }
}