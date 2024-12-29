//função para formatar o número no padrão 'xx.xxx,xx'
function formatarNumero(numero) {
    return numero.toFixed(2)                     
        .replace('.', ',')                         
        .replace(/\B(?=(\d{3})+(?!\d))/g, '.');    
}

$(document).ready(function () {
    atualizarSelectInstituicoes();
    atualizarTabelaInstituicoes();
});

function atualizarTabelaInstituicoes(instituicoes) {
    const tbody = $('#instituicoesTableBody');
    tbody.empty(); 

    if (instituicoes.length === 0) {
        $('#totalSaldo').text('R$ 0,00');
        $('#totalFatura').text('R$ 0,00');
        return;
    }

    let totalSaldo = 0;
    let totalFatura = 0;

    instituicoes.forEach(function (instituicao) {
        const tr = $('<tr>');

        tr.append($('<td>').text(instituicao.nome));
        tr.append($('<td>').addClass('saldo').text('R$ ' + instituicao.receita.toFixed(2)));
        tr.append($('<td>').addClass('fatura').text('R$ ' + instituicao.despesa.toFixed(2)));

        tbody.append(tr);

        totalSaldo += instituicao.receita;
        totalFatura += instituicao.despesa;
    });

    $('#totalSaldo').text('R$ ' + formatarNumero(totalSaldo));
    $('#totalFatura').text('R$ ' + formatarNumero(totalFatura));
}

$(document).ready(function () {
    $('#tipo-transacao').change(function () {
        const tipoTransacao = $(this).val();
        if (tipoTransacao === 'Crédito') {
            $('#parcelas-container').show(); 
        } else {
            $('#parcelas-container').hide(); 
            $('#numero-parcelas').val('');  
        }
    });

    $('#tipo-transacao').trigger('change');
});

$(document).ready(function () {
    function ajustarAlturaSection() {
        const instituicaoFieldset = $(".add-instituicao fieldset");
        const receitaDespesaFieldset = $(".add-receita-despesa fieldset");

        const alturaInstituicao = instituicaoFieldset.outerHeight(true); 
        const alturaReceitaDespesa = receitaDespesaFieldset.outerHeight(true); 

        const maxHeight = Math.max(alturaInstituicao, alturaReceitaDespesa);

        $(".add-instituicao").height(maxHeight);
        $(".add-receita-despesa").height(maxHeight);
    }

    //ajusta a altura quando a página é carregada
    ajustarAlturaSection();

    //ajusta a altura sempre que um campo for alterado
    $("#instituicaoForm input, #receitaDespesaForm input, #receitaDespesaForm select").on("change", function () {
        ajustarAlturaSection();
    });
});
