using System;
using ExpenseService;
using ExpenseService.Exceptions;
using ExpenseService.Expense;
using ExpenseService.Projects;
using Xunit;

namespace ExpenseServiceTest
{
    public class ExpenseServiceTest
    {
        [Fact]
        public void Should_return_internal_expense_type_if_project_is_internal()
        {
            // given
            ExpenseType expectedExpenseType = ExpenseType.INTERNAL_PROJECT_EXPENSE;
            Project internalProject = new Project(ProjectType.INTERNAL, "Internal Project");

            // when
            ExpenseType actualExpenseType = ExpenseService.ExpenseService.GetExpenseCodeByProjectTypeAndName(internalProject);

            // then
            Assert.Equal(expectedExpenseType, actualExpenseType);
        }

        [Fact]
        public void Should_return_expense_type_A_if_project_is_external_and_name_is_project_A()
        {
            // given
            ExpenseType expectedExpenseType = ExpenseType.EXPENSE_TYPE_A;
            Project typeAProject = new Project(ProjectType.EXTERNAL, "Project A");

            // when
            ExpenseType actualExpenseType = ExpenseService.ExpenseService.GetExpenseCodeByProjectTypeAndName(typeAProject);

            // then
            Assert.Equal(expectedExpenseType, actualExpenseType);
        }

        [Fact]
        public void Should_return_expense_type_B_if_project_is_external_and_name_is_project_B()
        {
            // given
            ExpenseType expectedExpenseType = ExpenseType.EXPENSE_TYPE_B;
            Project typeBProject = new Project(ProjectType.EXTERNAL, "Project B");

            // when
            ExpenseType actualExpenseType = ExpenseService.ExpenseService.GetExpenseCodeByProjectTypeAndName(typeBProject);

            // then
            Assert.Equal(expectedExpenseType, actualExpenseType);
        }

        [Fact]
        public void Should_return_other_expense_type_if_project_is_external_and_has_other_name()
        {
            // given
            ExpenseType expectedExpenseType = ExpenseType.OTHER_EXPENSE;
            Project otherProject = new Project(ProjectType.EXTERNAL, "Other Project");

            // when
            ExpenseType actualExpenseType = ExpenseService.ExpenseService.GetExpenseCodeByProjectTypeAndName(otherProject);

            // then
            Assert.Equal(expectedExpenseType, actualExpenseType);
        }

        [Fact]
        public void Should_throw_unexpected_project_exception_if_project_is_invalid()
        {
            // given
            Project unexpectedProject = new Project(ProjectType.UNEXPECTED_PROJECT_TYPE, "Unexpected Project");

            // when
            Action action = () => ExpenseService.ExpenseService.GetExpenseCodeByProjectTypeAndName(unexpectedProject);

            // then
            UnexpectedProjectTypeException exception = Assert.Throws<UnexpectedProjectTypeException>(action);
            Assert.Equal("You enter invalid project type", exception.Message);
        }
    }
}