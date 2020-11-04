using ExpenseService;
using ExpenseService.Exceptions;
using ExpenseService.Expense;
using ExpenseService.Projects;
using Xunit;
using static ExpenseService.ExpenseService;

namespace ExpenseServiceTest
{
    public class ExpenseServiceTest
    {
        [Fact]
        public void Should_return_internal_expense_type_if_project_is_internal()
        {
            // given
            var project = new Project(ProjectType.INTERNAL, "any");
            // when
            var expenseType = GetExpenseCodeByProjectTypeAndName(project);
            // then
            Assert.Equal(ExpenseType.INTERNAL_PROJECT_EXPENSE, expenseType);
        }

        [Fact]
        public void Should_return_expense_type_A_if_project_is_external_and_name_is_project_A()
        {
            // given
            var project = new Project(ProjectType.EXTERNAL, "Project A");
            // when
            var expenseType = GetExpenseCodeByProjectTypeAndName(project);
            // then
            Assert.Equal(ExpenseType.EXPENSE_TYPE_A, expenseType);
        }

        [Fact]
        public void Should_return_expense_type_B_if_project_is_external_and_name_is_project_B()
        {
            // given
            var project = new Project(ProjectType.EXTERNAL, "Project B");
            // when
            var expenseType = GetExpenseCodeByProjectTypeAndName(project);
            // then
            Assert.Equal(ExpenseType.EXPENSE_TYPE_B, expenseType);
        }

        [Fact]
        public void Should_return_other_expense_type_if_project_is_external_and_has_other_name()
        {
            // given
            var project = new Project(ProjectType.EXTERNAL, "Project C");
            // when
            var expenseType = GetExpenseCodeByProjectTypeAndName(project);
            // then
            Assert.Equal(ExpenseType.OTHER_EXPENSE, expenseType);
        }

        [Fact]
        public void Should_throw_unexpected_project_exception_if_project_is_invalid()
        {
            // given
            var project = new Project(ProjectType.UNEXPECTED_PROJECT_TYPE, "Ugly Project");
            // when
            // then
            Assert.Throws<UnexpectedProjectTypeException>(() =>
            {
                GetExpenseCodeByProjectTypeAndName(project);
            });
        }
    }
}
