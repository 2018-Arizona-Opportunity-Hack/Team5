import com.google.gson.Gson;

public class Request{
	private URL url;
	private String json;
	private Gson gson;

	public Request(FormDetails form){
		url = new URL("https://hackathonformapi.azurewebsites.net/api/FormDetails");
		gson = new Gson();
		json = gson.toJson(form);
	}

	public makeRequest(){
		URLConnection connect = url.openConnection();
		HttpURLConnection http = (HttpURLConnection)connect;
		http.setRequestMethod("POST");
		http.setDoOutput(true);

		http.setRequestProperty("Content-Type", "application/json; charset=UTF-8");
		http.connect();
		try (OutputStream os = http.getOutputStream()){
			os.write(json);
		}
	}
}