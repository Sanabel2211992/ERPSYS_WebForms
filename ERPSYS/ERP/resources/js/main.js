
(function () {
    var main = window.main = {};
    var grid;

    main.GridCreated = function (sender) {
        grid = sender;
    };

    main.HierarchyExpanded = function (sender, args) {
        var firstClientDataKeyName = args.get_tableView().get_clientDataKeyNames()[0];
    }

    main.HierarchyCollapsed = function (sender, args) {
        var firstClientDataKeyName = args.get_tableView().get_clientDataKeyNames()[0];
    }

    main.ExpandCollapseFirstMasterTableViewItem = function () {
        var firstMasterTableViewRow = grid.get_masterTableView().get_dataItems()[0];
        if (firstMasterTableViewRow.get_expanded()) {
            firstMasterTableViewRow.set_expanded(false);
            }
            else {
            firstMasterTableViewRow.set_expanded(true);
            }
        }
})();