using DictonaryApp.DTO.Request;
using DictonaryApp.DTO.Responce;
using DictonaryApp.Models;
using SQLite;


namespace DictonaryApp.Repositories
{
    public class DictionaryRepository
    {
        string _dbPath;
        private SQLiteAsyncConnection conn;

        public string StatusMessage { get; set; }


        private void Init()
        {
            if (conn != null)
                return;

            conn = new SQLiteAsyncConnection(_dbPath);

            conn.CreateTableAsync<DictionaryModel>();
            conn.CreateTableAsync<WordModel>();
        }

        public DictionaryRepository(string dbPath)
        {
            _dbPath = dbPath;
        }

        public async Task<bool> AddNewDictionary(DictionaryRequestDTO request)
        {
            int result;
            try
            {
                Init();

                // basic validation to ensure a name was entered
                if (string.IsNullOrEmpty(request.Name))
                    throw new Exception("Valid name required");
                if (string.IsNullOrEmpty(request.LanguageFrom))
                    throw new Exception("Valid language required");
                if (string.IsNullOrEmpty(request.LanguageTo))
                    throw new Exception("Valid language required");

                result = 
                await conn.InsertAsync(new DictionaryModel { 
                    Name = request.Name, 
                    LanguageFrom = request.LanguageFrom, 
                    LanguageTo = request.LanguageTo, 
                    CreationDate = DateTime.Now
                });

                StatusMessage = string.Format("{0} record(s) added ({1})", result, request);
                return true;
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to add {0}. Error: {1}", request, ex.Message);
            }
            return false;
        }

        public async Task<List<DictionaryResponceDTO>> GetAllDictionaries()
        {
            try
            {
                Init();
                var dicts = await conn.Table<DictionaryModel>().ToListAsync();
                return dicts.Select(x => new DictionaryResponceDTO
                {
                    Name = x.Name[..Math.Min(x.Name.Length, 12)],
                    LanguageFrom = x.LanguageFrom,
                    LanguageTo = x.LanguageTo,
                    Id = x.Id,
                    CreationDate = x.CreationDate
                }).ToList();
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
            }

            return new List<DictionaryResponceDTO>();
        }

        internal async Task<DictionaryResponceDTO> GetOneDictionary(int id)
        {
            try
            {
                Init();
                var x = await conn.Table<DictionaryModel>().FirstAsync(x=>x.Id==id);
                return  new DictionaryResponceDTO
                {
                    Name = x.Name,
                    LanguageFrom = x.LanguageFrom,
                    LanguageTo = x.LanguageTo,
                    Id = x.Id,
                    CreationDate = x.CreationDate
                };
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
            }

            return new DictionaryResponceDTO();
        }

        internal async Task<bool> UpdateDictionary(int idDictionary, DictionaryRequestDTO request)
        {
            int result;
            try
            {
                Init();

                // basic validation to ensure a name was entered
                if (string.IsNullOrEmpty(request.Name))
                    throw new Exception("Valid name required");
                if (string.IsNullOrEmpty(request.LanguageFrom))
                    throw new Exception("Valid language required");
                if (string.IsNullOrEmpty(request.LanguageTo))
                    throw new Exception("Valid language required");


                result = await conn.UpdateAsync(new DictionaryModel
                {
                    Name = request.Name,
                    LanguageFrom = request.LanguageFrom,
                    LanguageTo = request.LanguageTo,
                    Id = idDictionary
                });
                

                StatusMessage = string.Format("{0} record(s) added ({1})", result, request);
                return true;
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to add {0}. Error: {1}", request, ex.Message);
            }
            return false;
        }

        internal async void DeleteDict(int id)
        {

            try
            {
                Init();

                await conn.DeleteAsync(new DictionaryModel { Id = id});

                StatusMessage = string.Format(" record deleted ({0})", id);

            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to delete {0}. Error: {1}", id, ex.Message);
            }
        }
        public async Task<bool> AddNewWordToDictionary(WordRequestDTO request)
        {
            int result;
            try
            {
                Init();

                // basic validation to ensure a name was entered
                if (string.IsNullOrEmpty(request.TextFrom))
                    throw new Exception("Valid text required");
                if (string.IsNullOrEmpty(request.TextTo))
                    throw new Exception("Valid text required");
                if (request.IdDictionary <= 0 )
                    throw new Exception("Valid dictionary required");

                var dictionary = await conn.FindAsync<DictionaryModel>(x => x.Id == request.IdDictionary);
                
                if (dictionary == null)
                {
                    StatusMessage = string.Format("Failed to add {0}. Error: {1}", request, "Dictionary not found");
                    return false;
                }

                result =
                await conn.InsertAsync(new WordModel
                {
                    ToWord = request.TextTo,
                    FromWord = request.TextFrom,
                    DictionaryId = dictionary.Id,
                    Dictionary = dictionary,
                    CreationDate = DateTime.Now
                });

                StatusMessage = string.Format("{0} record(s) added ({1})", result, request);
                return true;
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to add {0}. Error: {1}", request, ex.Message);
            }
            return false;
        }

        internal async Task<List<WordResponceDTO>> GetAllWordsByDictionary(int id)
        {
            try
            {
                Init();
                var dicts = await conn.Table<WordModel>().Where(x => x.DictionaryId == id).ToListAsync();
                return dicts.Select(x => new WordResponceDTO
                {
                    WordFrom = x.FromWord[..Math.Min(x.FromWord.Length, 12)],
                    WordTo = x.ToWord[..Math.Min(x.ToWord.Length, 12)],
                    Id = x.Id,
                }).ToList();
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
            }

            return new List<WordResponceDTO>();
        }

        internal async Task<WordResponceDTO> GetOneWord(int id)
        {
            try
            {
                Init();
                var x = await conn.Table<WordModel>().FirstAsync(x => x.Id == id);
                return new WordResponceDTO
                {
                   WordFrom = x.FromWord,
                   WordTo = x.ToWord,
                    Id = x.Id,
                    IdDictionary = x.DictionaryId
                };
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
            }

            return new WordResponceDTO();
        }

        internal async Task<bool> EditWordToDictionary(int id, WordRequestDTO request)
        {
            int result;
            try
            {
                Init();

                // basic validation to ensure a name was entered
                if (string.IsNullOrEmpty(request.TextFrom))
                    throw new Exception("Valid text required");
                if (string.IsNullOrEmpty(request.TextTo))
                    throw new Exception("Valid text required");

                

                result =
                await conn.UpdateAsync(new WordModel
                {
                    ToWord = request.TextFrom,
                    FromWord = request.TextTo,
                    Id = id
                });

                StatusMessage = string.Format("{0} record(s) updated ({1})", result, request);
                return true;
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to update {0}. Error: {1}", request, ex.Message);
            }
            return false;
        }

        internal async void DeleteWord(int id)
        {
            try
            {
                Init();

                await conn.DeleteAsync(new WordModel { Id = id });

                StatusMessage = string.Format(" record deleted ({0})", id);

            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to delete {0}. Error: {1}", id, ex.Message);
            }
        }
    }
}