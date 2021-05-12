/**
 * plugin popup
 */

import Popup from './popup.vue';

Popup.install = (Vue, options = {}) => {
    let MyComponent = Vue.extend({
        render: h=> {
            return h(Popup,{
                props:{
                    options: options
                },
                ref: "Popup"
            })
        }
    })
    var component = new MyComponent().$mount()
    document.body.appendChild(component.$el)
    Vue.prototype.$_Popup = component.$refs.Popup
}
export default Popup;