using Application.Interface.SecurityModule.Transaction;
using Domain.Entities.SecurityModule.Master;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Application.Repository.SecurityModule.Transaction
{
    public class CreateMasterForm : ICreateMasterFront
    {
        protected HUB_Context _Context;

        public CreateMasterForm(HUB_Context context)
        {
            _Context = context;
        }
        public async Task<bool> CreateFormMaster(string TableName)
        {
            var dataTable = new DataTable();
            using (var connection = new SqlConnection(_Context.Database.GetDbConnection().ConnectionString))
            {
                SqlCommand command = new SqlCommand();
                connection.Open();
                command.Connection = connection;
                command.CommandText = string.Format(@" SELECT *
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = N'{0}'
		", TableName);
                var dataReader = command.ExecuteReader();

                dataTable.Load(dataReader);
            }
            string Gridcolumns = "[";
            string Reset = "{";
            for (int i = 0;i< dataTable.Rows.Count;i++)
            {
                Reset = Reset + string.Format(
                    @"{0}:{1}{2}", dataTable.Rows[i]["COLUMN_NAME"], "0", i != dataTable.Rows.Count - 1 ? "," : "");
                Gridcolumns = Gridcolumns +string.Format( @"{2}
      field: '{0}',
      headerName:'{0}',
      sortable: true, filter: true, width: 200
    {3}{1}", dataTable.Rows[i]["COLUMN_NAME"],i< dataTable.Rows.Count-1?",":"","{","}");
            }
            Gridcolumns = Gridcolumns + "]";
            Reset = Reset + "}";
            string Ts = string.Format(@"

@Component({3}
  selector: 'app-{0}',
  templateUrl: '.{0}.component.html',
  styleUrls: ['.{0}.component.scss']
{4})
export class {0}Componenet implements OnInit{3}
  checkLang=false;
  public _IPrgPer:IPrgPer;

  ngOnInit(){3}
    if (localStorage.getItem('Lang') == 'en') {3}
      this.checkLang=true;
      {4}
      else {3} this.checkLang=false;{4}

    this.getAll();
  {4}
  title = """";
  edit = false;
  modalRef: BsModalRef;

  columnDefs: any = {2}
  rowSelection = 'single';
  api: any;

  @ViewChild('upsertForm') template: TemplateRef<any>;

  constructor(
    public cd: ChangeDetectorRef,
    public translate: TranslateService,
    private modalService: BsModalService,
    private spinner: NgxSpinnerService,
    private _ActivatedRoute: ActivatedRoute,
    public _GroupPermissionService:GroupPermissionService,

    public {0}Service:{0}Service) {3}
      this._IPrgPer={3}
        delete:false,
        edit:false,
        excel:false,
        insert:true,
        print:false,
        progId:0,
        read:false,
        recordList:false,
        sysId:0,
        userId:0
      {4}
      this._ActivatedRoute.data.subscribe(data => {3}

        this. _GroupPermissionService.GetProgpermissionperuser(data.ProgId, localStorage.getItem(""id"")).subscribe(x=>
         {3}
           this._IPrgPer=x;
           cd.detectChanges()
         {4})

       {4});
      this.reset();
     {4}

     reset() {3}
      this.{0}Service.{0}={2]
    {4}

  onGridReady(params) {3}
    this.api = params.api;
    this.spinner.show();
    this.getAll();
  {4}
  getAll() {3}
    this.{0}Service.getall().subscribe(res => {3}
      this.api.setRowData(res);
      this.cd.detectChanges();
      this.spinner.hide();

    {4});
  {4}
  onrowDoubleClicked(params) {3}
    if(!this._IPrgPer.edit)
    {3}
      alert('ليس من حقك التعديل');
      return;
    {4}
    this.reset();
    this.edit = true;
    this.title = ""{0}.EDIT"";
    this.modalRef = this.modalService.show(this.template);
    this.{0}Service.{0} = params.data;
    this.cd.detectChanges();
  {4}
  show() {3}


    this.reset();
    this.edit = false;
    this.title = ""{0}.NEWCUSTOMER"";
    this.modalRef = this.modalService.show(this.template);

  {4}

  hide() {3}
    this.modalRef.hide();
    this.reset();
  {4}
  onSubmit(userF) {3}
    var isInvalid = userF.invalid

    if (!isInvalid) {3}
      if ( !this.{0}Service.{0}) {3}
        alert(""يجب ادخال البيانات صحيحه"")
        return;
      {4}
   

      if (!this.edit) {3}
        this.{0}Service.save().subscribe(res => {3}
          if(res==null){3}
            Swal.fire({3}
              icon: 'error',
              title: this.translate.instant(""ERRORS.ALREADYEXIST""),
              text: '',
            {4});
          return;
          {4}
          Swal.fire({3}
            icon: 'success',
            title: this.translate.instant(""INTERACTIONMESSAGE.SUCCESS""),
            showConfirmButton: true,
            timer:1500
          {4});
         this.getAll();
          this.reset();
          this.hide();
        {4})
      {4} else {3}
        this.{0}Service.update().subscribe(res => {3}
          this.getAll();
          this.reset();
          this.hide();
        {4})
      {4}
    {4}
  {4}
  deleteEvent() {3}
    if (confirm(""Are you sure you want to delete User?"")){3}
      this.{0}Service.delete().subscribe(res => {3}
        if(res==false){3}
          alert(""هذا العميل له عقود قم بحذف العقد اولا"");
          return;
        {4}
        this.getAll();
        this.hide();
      {4});
    {4}
  {4}

  {4}



", TableName, Gridcolumns, Reset,"{","}");
            return true;
        }
    }
}
