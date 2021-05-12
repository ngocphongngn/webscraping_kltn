/**
 * plugin notifications
 */

import Notification from './type';

Notification.install = (Vue, options = {}) => {
    let MyComponent = Vue.extend({
        render: h=> {
            return h(Notification,{
                props:{
                    options: options
                },
                ref: "Notification"
            })
        }
    })
    var component = new MyComponent().$mount()
    document.body.appendChild(component.$el)
    Vue.prototype.$_Notification = component.$refs.Notification
}
export default Notification;