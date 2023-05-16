using System.ComponentModel.DataAnnotations;

namespace JobSearch.Models
{
    public class JobSearch
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string Position { get; set; }
        public DateTime DateSubmitted { get; set; }
        public DateTime FollowUpDate { get; set; }
        [StringLength(255)]
        public string LinkConnections { get; set; }
        public DateTime PhoneInterview {  get; set; }
        [StringLength(255)]
        public string PhoneInterviewerNames { get; set; }
        public DateTime F2FInterview { get; set; }
        [StringLength(255)]
        public string F2FInterviewerNames { get; set; }
        public DateTime FollowUpDates { get; set; }
        [StringLength(2000)]
        public string Notes { get; set; }
        public JobSearch() { }
    }
}
