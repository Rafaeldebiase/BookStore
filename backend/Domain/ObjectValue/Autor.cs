namespace bookstore.domain.objectvalue
{
    public class  Autor
    {
        public Autor(string primeiroNomeDoAutor, string sobreNomeDoAutor)
        {
            PrimeiroNomeDoAutor = primeiroNomeDoAutor;
            SobreNomeDoAutor = sobreNomeDoAutor;
        }

        public string PrimeiroNomeDoAutor { get; private set; }
        public string SobreNomeDoAutor { get; private set; }
    }
}