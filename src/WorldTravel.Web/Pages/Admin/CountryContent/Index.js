$(function () {
    var l = abp.localization.getResource('WorldTravel');
    var createModal = new abp.ModalManager(abp.appPath + 'Admin/Form/Create');
    var editModal = new abp.ModalManager(abp.appPath + 'Admin/Form/Edit');

    var getFilter = function () {
        return {
            countryNameFilter: $("#CountryNameFilter").val()
        };
    };

    var dataTable = $('#CountryContentsTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [],
            searching: false,
            scrollX: true,
            ajax: abp.libs.datatables.createAjax(worldTravel.services.counrtyContent.getCounrtyContentList, getFilter),
            columnDefs: [
                {
                    title: l('Actions'),
                    rowAction: {
                        items:
                            [
                                {
                                    text: l('Edit'),
                                    //visible: abp.auth.isGranted('WorldTravel.Forms.Edit'),
                                    action: function (data) {
                                        worldTravel.services.counrtyContent.updateCounrtyContent(data.record.id)
                                            .done(function (result) {
                                                if (result.success) {
                                                    toastr.success(result.message)
                                                    dataTable.ajax.reload();
                                                }
                                                else {
                                                    toastr.error(result.message)
                                                }
                                            })
                                            .fail(function () {
                                                toastr.error('@L["UnexpectedError"].Value');
                                            });
                                    }
                                },
                                {
                                    text: l('Delete'),
                                    //visible: abp.auth.isGranted('WorldTravel.Forms.Delete'),
                                    confirmMessage: function (data) {
                                        return l('DeleteConfirmMessage', data.record.name);
                                    },
                                    action: function (data) {
                                        worldTravel.services.counrtyContent.softDelete(data.record.id)
                                            .then(function () {
                                                abp.notify.info(l('SuccessfullyDeleted'));
                                                dataTable.ajax.reload();
                                            });
                                    }
                                }
                            ]
                    }
                },
                {
                    title: l('Title'),
                    data: "title",
                    render: function (data) {
                        return data;
                    }
                },
                {
                    title: l('Description'),
                    data: "description",
                    render: function (data) {
                        return data;
                    }
                },
                {
                    title: l('CountryName'),
                    data: "countryName",
                    render: function (data) {
                        return data;
                    }
                },
                {
                    title: l('Image'),
                    data: "previewImageUrl",
                    render: function (data) {
                        return setImage200(data);
                    }
                },
                {
                    title: l('ReadCount'),
                    data: "readCount",
                    render: function (data) {
                        return data;
                    }
                },
                {
                    title: l('TotalImageCount'),
                    data: "totalImageCount",
                    render: function (data) {
                        return data;
                    }
                },
                {
                    title: l('TotalVideoCount'),
                    data: "totalVideoCount",
                    render: function (data) {
                        return data;
                    }
                },
                {
                    title: l('CreatedDate'),
                    data: "createdDate",
                    render: function (data) {
                        return setDate(data);
                    }
                }
            ],
            createdRow: function (nRow, aData) {
            }
        })
    );


    createModal.onResult(function () {
        dataTable.ajax.reload();
        abp.notify.info(l('SuccessfullyCompleted'));
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
        abp.notify.info(l('SuccessfullyCompleted'));
    });

    $('#createButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });

    $('#btnSearch').on('click', function (e) {
        $('.loading').show();

        dataTable.ajax.reload(() => {
            $('.loading').hide();
        });
    });
});