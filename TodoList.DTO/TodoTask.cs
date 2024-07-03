namespace TodoList.DTO {
    public class TodoTask {
        public long Id { get; set; }
        public string? Name { get; set; }
        public bool IsComplete { get; set; }
        //public long TodoListId { get; set; }
        public override string ToString() => Name ?? string.Empty;

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