export function getCookie(key: string) {
    const b = document.cookie.match("(^|;)\\s*" + key + "\\s*=\\s*([^;]+)");
    return b ? b.pop() : "";
}

export function currencyFormat(amount: number){
    return '$' + (amount/100).toFixed(2);
}

export function getPrice(price: number, pricePercent = 100 , quantity = 1)
{
    return '$' + (Math.round(pricePercent/100 * price * quantity)/100).toFixed(2);
}