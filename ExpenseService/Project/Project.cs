using System;
namespace ExpenseService.Projects
{
    public class Project
    {
        public Project(ProjectType projectType, string projectName)
        {
            this.ProjectType = projectType;
            this.ProjectName = projectName;
        }

        public ProjectType ProjectType { get; private set; }

        public string ProjectName { get; private set; }
    }
}
