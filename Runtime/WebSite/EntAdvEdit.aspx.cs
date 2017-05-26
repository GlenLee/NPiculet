using System;
using System.Data;
using System.IO;
using System.Linq;
using NPiculet.Base.EF;
using NPiculet.Logic.Base;
using NPiculet.Logic.Data;
using NPiculet.Toolkit;

public partial class EntAdvEdit : MemberPage
{
	readonly NPiculetEntities _db = new NPiculetEntities();
	protected void Page_Load(object sender, EventArgs e)
	{
		if (Page.IsPostBack)
			return;
		this.Id.Value = WebParmKit.GetRequestString("key", 0).ToString();
		BindData();
	}

	private void BindData()
	{
		this.Type.DataSource = AdvHelper.AllAdvTypes;
		this.Type.DataBind();

		if (CurrentUserInfo == null)
			return;

		var advId = Convert.ToInt32(this.Id.Value);
		if (advId <= 0)
			return;
		var model = _db.cms_adv_info.SingleOrDefault(x => x.Creator == CurrentUserInfo.Account && x.Id == advId);
		if (model == null)
			return;
		BindKit.BindModelToContainer(this.EntAdvEditor, model);
		ShowThumb(model.Image);
	}

	private void ShowThumb(string imagePath)
	{
		if (!string.IsNullOrEmpty(imagePath))
		{
			this.ImageHyperLink.NavigateUrl = imagePath;
			this.PreviewImage.ImageUrl = imagePath;
			this.PreviewImage.Visible = true;
		}
		else
		{
			this.PreviewImage.Visible = false;
		}
	}

	protected void btnSave_Click(object sender, EventArgs e)
	{
		if (!Page.IsValid)
			return;
		var model = _db.cms_adv_info.Create();
		BindKit.FillModelFromContainer(this.EntAdvEditor, model);

		if (!string.IsNullOrEmpty(this.AdvImage.FileName))
		{
			//清理老图像
			if (!string.IsNullOrEmpty(this.PreviewImage.ImageUrl))
			{
				var f = new FileInfo(Server.MapPath(this.PreviewImage.ImageUrl));
				if (f.Exists) f.Delete();
			}
			//更新新图
			model.Image = FileKit.SaveThumbnailImage(this.AdvImage.PostedFile, 1024, 1024);
		}
		if (this.Id.Value == "0")
		{
			model.Click = 0;
			model.IsEnabled = -1;
			model.CreateDate = DateTime.Now;
			model.Creator = this.CurrentUserName;
			model.LoopEnd = "0";
			model.LoopStart = "0";
			model = _db.cms_adv_info.Add(model);
			_db.SaveChanges();
			Id.Value = model.Id.ToString();
		}
		else
		{
			model = _db.cms_adv_info.Find(int.Parse(this.Id.Value));
			BindKit.FillModelFromContainer(this.EntAdvEditor, model);
			model.IsEnabled = -1;
			_db.Entry(model).State = System.Data.Entity.EntityState.Modified;
			_db.SaveChanges();
		}

		ShowThumb(model.Image);
		this.promptControl.ShowSuccess("保存成功！");
	}

	protected void btnGoBack_Click(object sender, EventArgs e)
	{
		Response.Redirect("EntAdvList.aspx");
	}
}