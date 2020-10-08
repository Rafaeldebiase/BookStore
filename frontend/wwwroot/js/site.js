
const dataPatch = []
const urlBuscaTodos = "http://localhost:5000/rest/Livro/buscartodos"

const newTable = (url) => {
    var newtable = $("#dataTable").DataTable({
        language: {
            "zeroRecords": "Sem dados"
        },
        ajax:{
                url: url,
                type: "GET",
                dataType:"json",
                dataSrc: ''
                },
        columns: [
            { data: "codigo" },
            { data: "titulo" },
            { data: "subTitulo" },
            { data: "autor",
                render: function(data, type, row){
                    return data.primeiroNomeDoAutor + ' '+ data.sobreNomeDoAutor
                }},
            { data: "isbn" },
            { data: "anoDeLancamento" },
            {defaultContent: "<div class='text-center'><div class='btn-group'><button class='btn btn-primary btn-sm btnEditar'><i class='material-icons'>edit</i></button><button class='btn btn-danger btn-sm btnExcluir'><i class='material-icons'>delete</i></button></div></div>"}
        ],
        aaSorting: [[1, "asc"]]
    })
    return newtable
}

var table = newTable(urlBuscaTodos)

$("#formIncluir[ajax=true]").submit(function(event) {
    event.preventDefault();
    var dados = {
        Titulo: $("#titulo").val(),
        SubTitulo: $("#subtitulo").val(),
        PrimeiroNome: $("#primeironome").val(),
        Sobrenome: $("#sobrenome").val(),
        Isbn: $("#isbn").val(),
        AnoDeLancamento: $("#ano").val().toString()
    }
    $.ajax({
        url: "http://localhost:5000/rest/Livro/inserir",
        method: "post",
        processData: false,
        cache: false,
        contentType: 'application/json',
        data:JSON.stringify(dados)
    }).done((resposta) => {
        table.ajax.reload(null, false) 
    })

    limparFormularioIncluir()
    $("#modalIncluir").modal("hide")
})

const limparFormularioIncluir = () => {
    $("#formIncluir").find('input').val('')
}

$(document).on("click", ".btnEditar", function(){		
    const row = $(this).closest("tr");	       
    const codigo = parseInt(row.find('td:eq(0)').text());
    const titulo = row.find('td:eq(1)').text();
    const subtitulo = row.find('td:eq(2)').text();

    const autor = row.find('td:eq(3)').text();
    const nomeCompleto = autor.split(" ");
    const PrimeiroNome = nomeCompleto[0]
    const sobrenome = nomeCompleto[1]

    const isbn = row.find('td:eq(4)').text();
    const ano = parseInt(row.find('td:eq(5)').text());
	
    $("#codigo").val(codigo)
    $("#tituloEdit").val(titulo)
    $("#subtituloEdit").val(subtitulo)
    $("#primeironomeEdit").val(PrimeiroNome)
    $("#sobrenomeEdit").val(sobrenome)
    $("#isbnEdit").val(isbn)
    $("#anoEdit").val(ano)
    $("#atualizar").prop("disabled", true)
    $("#modalEditar").modal("show")
});

$("#tituloEdit").change(() => {
    const data = {
            "op": "replace",
            "path": "/Titulo",
            "value": $("#tituloEdit").val()
        }
    dataPatch.push(data)
    $("#atualizar").prop("disabled", false)
})

$("#subtituloEdit").change(() => {
    const data = {
            "op": "replace",
            "path": "/SubTitulo",
            "value": $("#subtituloEdit").val()
        }
    dataPatch.push(data)
    $("#atualizar").prop("disabled", false)
})

$("#primeironomeEdit").change(() => {
    const data = {
            "op": "replace",
            "path": "/PrimeiroNome",
            "value": $("#primeironomeEdit").val()
        }
    dataPatch.push(data)
    $("#atualizar").prop("disabled", false)
})

$("#sobrenomeEdit").change(() => {
    const data = {
            "op": "replace",
            "path": "/Sobrenome",
            "value": $("#sobrenomeEdit").val()
        }
    dataPatch.push(data)
    $("#atualizar").prop("disabled", false)
})

$("#isbnEdit").change(() => {
    const data = {
            "op": "replace",
            "path": "/Isbn",
            "value": $("#isbnEdit").val()
        }
    dataPatch.push(data)
    $("#atualizar").prop("disabled", false)
})

$("#anoEdit").change(() => {
    const data = {
            "op": "replace",
            "path": "/AnoDeLancamento",
            "value": $("#anoEdit").val().toString()
        }
    dataPatch.push(data)
    $("#atualizar").prop("disabled", false)
})


$("#formEditar[ajax=true]").submit((event) => {
    event.preventDefault();
    const codigo = $("#codigo").val();

    const url = `http://localhost:5000/rest/Livro/atualizar/${codigo}`

    $.ajax({
        url: url,
        method: "PATCH",
        processData: false,
        cache: false,
        contentType: 'application/json',
        data:JSON.stringify(dataPatch)
    }).done((resposta) => {
        table.ajax.reload(null, false) 
    })
    limparFormularioEditar()
    $("#modalEditar").modal("hide")
})

const limparFormularioEditar = () => {
    $("#formEditar").find('input').val('')
}

$(document).on("click", ".btnExcluir", function(){
    const row = $(this)           
    const codigo = parseInt($(this).closest('tr').find('td:eq(0)').text()) 		     
    var resposta = confirm("Deseja apagar o livro " + codigo + "?")  
    
    const url = `http://localhost:5000/rest/Livro/apagar/${codigo}`

    if (resposta) {            
        $.ajax({
            url: url,
            method: "DELETE",
        }).done(() => {
            table.row(row.parents('tr')).remove().draw()    
        })  
    }
})



const pesquisar = () => {
    let url = ""
    const opcao = $("#pesquisaavancada").val();
    const pesquisa = $("#pesquisa").val()

    console.log(opcao)

    switch (opcao) {
        case '0':
            url = `http://localhost:5000/rest/Livro/buscarpelocodigo/${pesquisa}`
            break
        case '1':
            url = `http://localhost:5000/rest/Livro/buscarpelotitulo/${pesquisa}`
            break
        default:
            url = `http://localhost:5000/rest/Livro/buscarpeloisbn/${pesquisa}`
            break
    }
        table.destroy()
        table = newTable(url) 
        
}
