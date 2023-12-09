function encodeAndDecodeMessages() {
    const btns = Array.from(document.getElementsByTagName("button"));
    let encodeBtn;
    let decodeBtn;

    for (let i = 0; i < btns.length; i++) {
        if(btns[i].textContent.includes("Encode")){
            btns[i].classList = "encode";
            encodeBtn = btns[i];
        } else {
            btns[i].classList = "decode";
            decodeBtn = btns[i];
        }
    }

    encodeBtn.addEventListener("click", encode);
    decodeBtn.addEventListener("click", decode);

    function encode(){
        const textArea = this.parentNode.querySelector("textarea");
        const messageToEncode = textArea.value;
        
        let encodedMessage = "";

        for (let i = 0; i < messageToEncode.length; i++) {
            encodedMessage += String.fromCharCode(messageToEncode[i].charCodeAt(0) + 1);
            
        }
        textArea.value = "";
        decodeBtn.parentNode.querySelector("textarea").value = encodedMessage;
    }
    
    function decode(){
        const textarea = this.parentNode.querySelector("textarea");
        const messageToDecode = textarea.value;
       
        
        let decodedMessage =""
        for (let i = 0; i < messageToDecode.length; i++) {
            decodedMessage +=String.fromCharCode(messageToDecode[i].charCodeAt(0) - 1)
            
        }
        textarea.value = decodedMessage;
    }

}