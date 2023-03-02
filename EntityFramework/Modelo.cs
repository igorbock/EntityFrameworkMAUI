namespace EntityFramework;

public class Modelo : DbContext
{
    private string _connection_string { get; set; }

    public Modelo(DbContextOptions<Modelo> p_options)
    {
        try
        {
            var m_diretorio = $"{Directory.GetCurrentDirectory()}\\appsettings.json";
            var m_conn = File.ReadAllText(m_diretorio);
            var m_jsonObject = JsonDocument.Parse(m_conn);
            _connection_string = m_jsonObject.RootElement.GetProperty("ConnectionStrings").GetProperty("DefaultConnection").ToString();
        }
        catch (FileNotFoundException)
        {
        }
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_connection_string);

        base.OnConfiguring(optionsBuilder);
    }

    public DbSet<Produto> Produtos { get; set; }
    public DbSet<Setor> Setores { get; set; }
    public DbSet<Etiqueta> Etiquetas { get; set; }
    public DbSet<Solicitacao> Solicitacoes { get; set; }
}