namespace EmailSender.ResourceModels
{
    public class NewMailModel
    {
        public string Subject { get; set; }

        public string Body { get; set; }

        public string[] Recipients { get; set; }

        public string MailFrom { get; set; }
    }
}
