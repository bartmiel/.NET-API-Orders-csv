namespace NetlandRecruitingTask.Application.Contracts
{
    public interface ICsvRepository
    {
        public Task<IEnumerable<T>> ReadCSVAsync<T>(string pathFile);
    }
}