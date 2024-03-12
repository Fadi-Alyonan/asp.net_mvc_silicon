const formErrorHandler = (element, validationResult) => {
    let span = document.querySelector(`[data-valmsg-for="${element.name}"]`)
    if (validationResult) {
        element.classList.remove('input-validation-error')
        span.classList.remove('field-validation-error')
        span.classList.add('field-validation-valid')
        span.innerHTML = ''
    } else {
        element.classList.add('input-validation-error')
        span.classList.add('field-validation-error')
        span.classList.remove('field-validation-valid')
        span.innerHTML = element.dataset.valRequired
    }
}
const textValidator = (element, minLength = 2) => {
    if (element.value.length >= minLength) {
        formErrorHandler(element, true)
    } else {
        formErrorHandler(element, false)
    }
}
const checkBoxValidator = (element) => {
    if (element.checked) {
        formErrorHandler(element, true)
    } else {
        formErrorHandler(element, false)
    }
}
const emailValidator = (element) => {
    const regEx = /^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$/
    formErrorHandler(element, regEx.test(element.value))
}
const passworValidator = (element) => {
    if (element.dataset.valEqualtoOther !== undefined) {
        let password = document.getElementsByName(element.dataset.valEqualtoOther.replace('*', 'Form'))[0].value
        if (element.value === password) {
            formErrorHandler(element, true)
        } else {
            formErrorHandler(element, false)
        }
    } else {
        const regEx = /^(?=.*[A-Z])(?=.*\d)(?=.*[^A-Za-z\d]).{8,}$/
        formErrorHandler(element, regEx.test(element.value))
    }
}

let forms = document.querySelectorAll('form')
let inputs = forms[0].querySelectorAll('input')

inputs.forEach(input => {

    if (input.dataset.val === 'true') {
        if (input.type === 'checkbox') {
            input.addEventListener('change', (e) => {
                checkBoxValidator(e.target)
            })
        } else {

            input.addEventListener('keyup', (e) => {
                switch (e.target.type) {
                    case 'text':
                        textValidator(e.target)
                        break;
                    case 'email':
                        emailValidator(e.target)
                        break;
                    case 'password':
                        passworValidator(e.target)
                        break;
                    
                }
            })
        }
    }
})