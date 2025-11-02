namespace PdfMerger.Classes
{
    public class MetaData
    {
        public string Title { get; set; } = "";
        public string Author { get; set; } = "";
        public string Subject { get; set; } = "";
        public List<string> Keywords { get; set; } = new();
        public string Creator { get; set; } = "";

        private Dictionary<string, int> authorListFromDocuments = new();
        private Dictionary<string, int> titleListFromDocuments = new();
        private Dictionary<string, int> subjectListFromDocuments = new();
        private Dictionary<string, int> creatorListFromDocuments = new();
        private Dictionary<string, int> keywordsListFromDocuments = new();
        private static readonly char[] separator = [','];

        public string GetKeywords() => string.Join(",", Keywords);


        public List<string> GetListOfTitles() => GetSortedList(titleListFromDocuments);
        public List<string> GetListOfAuthors() => GetSortedList(authorListFromDocuments);
        public List<string> GetListOfSubjects() => GetSortedList(subjectListFromDocuments);
        public List<string> GetListOfCreators() => GetSortedList(creatorListFromDocuments);
        public List<string> GetListOfKeywords() => GetSortedList(keywordsListFromDocuments);

        public void AddKeywordsFromDocument(string keyword)
        {
            var keys = keyword.Split(separator);
            if (keys is null || !keys.Any())
            {
                return;
            }

            foreach (var key in keys)
            {
                AddOrUpdateDic(keywordsListFromDocuments, key);
            }
        }
        public void AddTitleFromDocument(string title) => AddOrUpdateDic(titleListFromDocuments, title);
        public void AddAuhtorFromDocument(string author) => AddOrUpdateDic(authorListFromDocuments, author);
        public void AddSubjectFromDocument(string subject) => AddOrUpdateDic(subjectListFromDocuments, subject);
        public void AddCreatorFromDocument(string creator) => AddOrUpdateDic(creatorListFromDocuments, creator);

        private void AddOrUpdateDic(Dictionary<string, int> dic, string key)
        {
            if (key is null || string.IsNullOrWhiteSpace(key))
            {
                return;
            }

            var keyTrimmed = key.Trim();
            if (dic.ContainsKey(keyTrimmed))
            {
                dic[keyTrimmed]++;
            }
            else
            {
                dic[keyTrimmed] = 1;
            }
        }

        private List<string> GetSortedList(Dictionary<string, int> dic) => dic.OrderByDescending(r => r.Value).Select(r => r.Key).ToList();
    }
}
