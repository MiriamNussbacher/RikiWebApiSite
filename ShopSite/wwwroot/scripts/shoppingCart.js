
const drawCart = () => {
    var cart = JSON.parse(localStorage.getItem('cart'));
    const template = document.getElementsByTagName("template")[0];
    if (cart != null) {
        cart.forEach(product => {
            var clone = template.content.cloneNode(true);
            clone.querySelector("img").src = `../images/${product.image}`;
            clone.querySelector(".descriptionColumn h3").innerText = `${product.name}`;
            clone.querySelector(".descriptionColumn h6").innerText = `${product.count}`;
            clone.querySelector(".price").innerText = `${product.price}`;
            clone.querySelector(".expandoHeight").addEventListener('click', (e) => deleteProductFromCart(cart, product))



            document.getElementsByTagName("tbody")[0].appendChild(clone);

        })
    }
    productAmountAndPrice(cart);
}

const productAmountAndPrice = (cart) => {
    
    const itemCount = cart?.reduce((count, product) => { return count + product.count }, 0) || 0; 
    const totalSum = cart?.reduce((sum, product) => { return sum + product.count * product.price }, 0) || 0; 

    document.getElementById("totalAmount").innerText = totalSum;
    document.getElementById("itemCount").innerText = itemCount;

}


    const deleteProductFromCart = (cart, product) => {
        cart[cart.indexOf(product)].count -= 1
        cart= cart.filter(pr=>pr.count > 0)
        localStorage.setItem('cart', JSON.stringify(cart))
        cleanScreen()
        drawCart();

    }

function cleanScreen() {
    document.getElementsByTagName("tbody")[0].innerText = '';

}

function cleanCart() {
    document.getElementById("totalAmount").innerText= 0
document.getElementById("itemCount").innerText = 0
    localStorage.removeItem('cart');
    cleanScreen();
}






const placeOrder = async() => { 
    const cart = JSON.parse(localStorage.getItem('cart'));

    const orderItems = cart.map(product => { return { 'ProductId': product.productId, 'Quantity': product.count } })

    const userId = JSON.parse(sessionStorage.getItem('CurrentUser'))?.id

    const orderSum = cart.reduce((sum, product) => { return sum + product.count * product.price }, 0); 

    const orderBody = { 'UserId': userId, 'OrderSum': orderSum, 'OrderItems': orderItems }

    if (!userId) alert(`You must sign in in order to place your order`)
    const response = await fetch(`api/orders`,
        {
            method: 'POST',
            body: JSON.stringify(orderBody),
            headers: {
                'Content-Type': 'application/json'
            }
        }
    );
    if (response.status == 201) {
        const order= await response.json();
        alert(`Your order #${order.orderId} has been successfully placed `)
        cleanCart()
    }


}

const loadPage = () => {
    window.addEventListener("load", drawCart)
}

loadPage()




















