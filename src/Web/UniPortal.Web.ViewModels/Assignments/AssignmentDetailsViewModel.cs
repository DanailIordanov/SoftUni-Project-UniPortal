﻿namespace UniPortal.Web.ViewModels.Assignments
{
    using System;
    using System.Collections.Generic;

    using UniPortal.Data.Models;
    using UniPortal.Services.Mapping.Contracts;
    using UniPortal.Web.ViewModels.Submissions;

    public class AssignmentDetailsViewModel : IMapFrom<Assignment>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime Deadline { get; set; }

        public int MaxPoints { get; set; }

        public IList<SubmissionIndexViewModel> Submissions { get; set; }

        public AssignmentStatus Status { get; set; }

        public string CourseId { get; set; }
    }
}
