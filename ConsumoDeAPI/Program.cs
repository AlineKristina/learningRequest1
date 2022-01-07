using Newtonsoft.Json;

HttpClient client = new HttpClient();
var response = await client.GetAsync("https://jsonplaceholder.typicode.com/users"); /* Sem await
                                                                                                * Vira uma task,
                                                                                                * Com await, 
                                                                                                * Vira um 
                                                                                                * HttpResponseMessage */
var content = await response.Content.ReadAsStringAsync();      // Sem o await só retorna o objeto,
Console.WriteLine(content);                                    // Com o await retorna o json


var deserializedContent = JsonConvert.DeserializeObject<Welcome[]>(content);
// Ainda retorna na estrutura do json, pois não tem tipo algum. QuickType converte o arquivo em uma classe
// Após criada a classe (pelo quicktype) correspondente ao objeto enviado no json,e adicionado esse tipo na
// função, que aceita generics, a deserialização acontece e o objeto é montado de acordo com o modelo.

foreach (var c in deserializedContent)
{
    Console.WriteLine(c.Name);
}