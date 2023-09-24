using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Capital_Placement_Task.Models
{
    public class Question
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public QuestionType QuestionType { get; set; }
        public QuestionBelongTo BelongsTo { get; set; }
        public string? ParagraphValue { get; set; }

        public string? ShortAnswerValue { get; set; }
        public virtual List<Choice>? Choices { get; set; }
        public bool? YESNO { get; set; }
        public DateTime? DatetValue { get; set; }

        public double? NumberValue { get; set; }
        public virtual List<Option>? Options { get; set; }
        public string? File { get; set; }
        public Boolean Hide { get; set; }
        public int ApplicationFormId { get; set; }
    }
    public enum QuestionBelongTo
    {
        Personal,
        Profile,
        Additional
    }
    public enum QuestionType
    {
        Paragraph,
        ShortAnswer,
        MultipleChoice,
        YesNo,
        Date,
        Number,
        Dropdown,
        FileUpload
    }
    public class Choice
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public int QuestionId { get; set; } // Foreign key to the Question entity

    }

    public class Option
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public int QuestionId { get; set; } // Foreign key to the Question entity

    }

}
