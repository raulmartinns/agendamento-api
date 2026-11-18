var builder = WebApplication.CreateBuilder(args);
//cria o contrutor da aplicação, carrega os appsetting,json, as configurações do log e o ambiente, o var deixa o compilador descobrir o tipo sozinho

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//registra serviços, diz ao .net que a aplicação tem disponivel, a primeira linha faz o .net mapear quais endpoints existem e a segunda gera documentação do swaggera a partir do mapa. 
//o builder.services é a injeção de dependencia, as coisas são registradas em um lugar só e o .net entrega pra quem precisar

var app = builder.Build();
//essa parte monta a aplicação com tudo que foi registrado ate essa linha, depois não da pra registrar mais servicos

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//configurar o pipeline (o caminho onde cada requisição passa)

app.MapGet("/health", () => Results.Ok(new { status = "ok" }));
/*
primeiro endpoint
MapGet responde requisicoes do tipo GET
"/health" o endereço
() => Results.Ok... e uma lambda, uma função curta que toda quando alguem chama o endereco dela, ela devolve HTTP 200 OK com JSon status ok 
*/

app.Run();