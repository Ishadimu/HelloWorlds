Ext.define('HelloWorlds.view.login.Login', {
    extend: 'Ext.container.Container',
    xtype: 'login',

    requires: [
        'Ext.plugin.Viewport',
        'Ext.window.MessageBox',

        'HelloWorlds.view.login.LoginController',
        'Ext.form.Panel'
    ],

    controller: 'login',
    plugins: 'viewport',

    style: { 
        backgroundImage: 'url(resources/images/world-at-night.jpeg)'
    },

    items: {
        xtype: 'window',
        bodyPadding: 10,
        title: 'Login',
        closable: false,
        autoShow: true,
        items: {
            xtype: 'form',
            reference: 'form',
            items: [
                {
                    xtype: 'textfield',
                    name: 'email',
                    fieldLabel: 'E-mail',
                    allowBlank: false
                }, 
                {
                    xtype: 'textfield',
                    name: 'password',
                    inputType: 'password',
                    fieldLabel: 'Password',
                    allowBlank: false
                }],
                buttons: [
                    {
                        text: 'Sign In',
                        formBind: true,
                        listeners: {
                            click: 'onLoginClick'
                        }
                    }
                ]
        }
        
    }
});