Ext.define('HelloWorlds.view.nav.Footer', {
    extend: 'Ext.panel.Panel',
    xtype: 'footer',

    requires: [
        'HelloWorlds.view.nav.FooterController'
    ],

    id: 'footer',    
    controller: 'footer',

    style: {
        borderTop: '1px solid lightgray'
    },

    layout: {
        type: 'hbox'
    },

    tbar: [
        {
            xtype: 'container',
            layout: {
                type: 'hbox',
                pack: 'center'
            },
            flex: 0.33,
            items: [
                {
                    html: 'Hello,Worlds! (ExtJS) - Created by <a href="https://www.ishadimu.com/" target="_blank">George Ishadimu</a>'
                }
            ]
        }
    ]
});