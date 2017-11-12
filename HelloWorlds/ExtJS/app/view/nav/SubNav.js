Ext.define('HelloWorlds.view.nav.SubNav', {
    extend: 'Ext.panel.Panel',
    xtype: 'subNav',

    requires: [
        'HelloWorlds.view.nav.SubNavController'
    ],

    controller: 'subNav',

    style: {
        borderBottom: '1px solid lightgray'
    },

    layout: {
        type: 'hbox'
    },

    viewModel: {
        formulas: {
            loginBtnTxt: {
                get: function () {
                    var loggedIn = localStorage.getItem("LoggedIn");

                    return loggedIn ? 'Log Out' : 'Log In';
                }
            }
        }
    },

    tbar: [
        {
            xtype: 'container',
            layout: {
                type: 'hbox',
                pack: 'start'
            },
            flex: 0.33,
            defaults: {
                cls: 'btn'
            },
            items: [
                {
                    xtype: 'button',
                    glyph: 'xf069@FontAwesome',
                    text: 'ExtJS'
                },
                {
                    xtype: 'button',
                    glyph: 'xf1d0@FontAwesome',
                    text: 'React'
                }
            ]
        },
        {
            xtype: 'container',
            layout: {
                type: 'hbox',
                pack: 'center'
            },
            flex: 0.33,
            items: [
                {
                    xtype: 'button',
                    tooltip: 'GitHub',
                    tooltipType: 'title',
                    glyph: 'xf09b@FontAwesome',
                    cls: ['btn', 'icon'],
                    handler: function() {
                        window.location = "http://helloworlds.ishadimu.com";
                    }
                }
            ]
        },
        {
            xtype: 'container',
            layout: {
                type: 'hbox',
                pack: 'end'
            },
            flex: 0.33,
            defaults: {
                cls: 'btn'
            },
            items: [
                {
                    xtype: 'button',
                    glyph: '',
                    bind: {
                        text: '{loginBtnTxt}'
                    },
                    handler: function () {
                        var loggedIn = localStorage.getItem('LoggedIn');

                        if (loggedIn)
                            localStorage.removeItem('LoggedIn');
                        else
                            localStorage.setItem('LoggedIn', true);
                    }
                }
            ]
        }
    ]
});