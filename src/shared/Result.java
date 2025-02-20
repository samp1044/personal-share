package shared;

public class Result<T> {
    private final boolean successful;
    private final T result;
    private final ErrorCode error;
    private final String message;

    public static <K> Result<K> Success(K result) {
        return new Result<K>(result);
    }

    public static <K> Result<K> Fail(ErrorCode error) {
        return new Result<K>(error, "");
    }

    public static <K> Result<K> Fail(ErrorCode error, String message) {
        return new Result<K>(error, message);
    }

    private Result(T result) {
        this.result = result;
        this.error = ErrorCode.None;
        this.message = "";
        this.successful = true;
    }

    private Result(ErrorCode error, String message) {
        this.result = null;
        this.error = error;
        this.message = message;
        this.successful = false;
    }

    public boolean isSuccess() {
        return this.successful;
    }

    public T getResult() {
        return this.result;
    }

    public ErrorCode GetError() {
        return this.error;
    }

    public String GetMessage() {
        return this.message;
    }
}
