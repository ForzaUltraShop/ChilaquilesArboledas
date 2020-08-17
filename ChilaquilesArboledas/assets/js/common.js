function castToCurrency(value) {
    var currency = parseFloat(value).toFixed(2).replace(/(\d)(?=(\d\d\d)+(?!\d))/g, "$1,");
    return '$' + currency;
}