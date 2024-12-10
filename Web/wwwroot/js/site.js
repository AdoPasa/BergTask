// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {
    $('#SynonymSearch').autocomplete({
        preProcess(res) {
            return res.data.map(r => r.name);
        },
    });

    $('#SynonymSearch').on('pick.bs.autocomplete', function (el, item) {
        window.location = $(this).data('redirect-url') + $(this).val();
    });

    let parentSearchResults = [];
    let foundItem = null;

    $('#ParentSynonymSearch').autocomplete({
        preProcess(res) {
            parentSearchResults = [...res.data];
            return res.data.map(r => r.name);
        },
    });

    $('#ParentSynonymSearch').on('pick.bs.autocomplete', function (el, item) {
        foundItem = parentSearchResults.find(prs => prs.name == $(this).val());

        if (foundItem)
        {
            $("#AddSynonymForm #ParentId").val(foundItem.id);
        }
    });

    $('#ParentSynonymSearch').on('blur', function () {
        if (!foundItem) {
            $("#AddSynonymForm #ParentId").val('');
            $("#ParentSynonymSearch").val('');
        }

        if (foundItem.name != $(this).val())
        {
            foundItem = null;
        }
    });
});