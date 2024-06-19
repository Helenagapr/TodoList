namespace TodoList.App.DTO {
    public class TodoTask {
        public string? Text {get; init;}
        public bool Completed {get; set; } = false;
        public override string ToString() => Text ?? string.Empty;

        /*
        public override string ToString() {
            return Text?? string.Empty;

            return Text == null ? string.Empty: Text;
            if (Text != null) return Text;
            return string.Empty;
            if (string.IsNullOrEmpty(Text)) return string.Empty;
            return Text;

        } */
    }
}